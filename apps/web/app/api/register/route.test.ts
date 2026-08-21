import { describe, expect, it, vi, afterEach } from "vitest";
import { NextRequest } from "next/server";

vi.mock("@/lib/turnstile", () => ({
  verifyTurnstileToken: vi.fn(),
}));

import { verifyTurnstileToken } from "@/lib/turnstile";
import { POST } from "./route";

function makeRequest(body: Record<string, unknown>): NextRequest {
  return new NextRequest("http://localhost/api/register", {
    method: "POST",
    body: JSON.stringify(body),
    headers: { "Content-Type": "application/json" },
  });
}

const validBody = {
  fullName: "Jane Doe",
  email: "jane@example.com",
  phone: "0770000000",
  password: "verysecurepassword",
  passwordConfirmation: "verysecurepassword",
  turnstileToken: "test-token",
};

describe("POST /api/register", () => {
  const originalFetch = global.fetch;

  afterEach(() => {
    global.fetch = originalFetch;
    vi.clearAllMocks();
  });

  it("returns 400 captcha_failed and does not call the API when Turnstile verification fails", async () => {
    vi.mocked(verifyTurnstileToken).mockResolvedValue(false);
    const fetchMock = vi.fn();
    global.fetch = fetchMock as unknown as typeof fetch;

    const response = await POST(makeRequest(validBody));
    const data = await response.json();

    expect(response.status).toBe(400);
    expect(data.error).toBe("captcha_failed");
    expect(fetchMock).not.toHaveBeenCalled();
  });

  it("returns 200 with the email on success", async () => {
    vi.mocked(verifyTurnstileToken).mockResolvedValue(true);
    global.fetch = vi.fn().mockResolvedValue({
      status: 200,
      json: async () => ({ email: "jane@example.com" }),
    }) as unknown as typeof fetch;

    const response = await POST(makeRequest(validBody));
    const data = await response.json();

    expect(response.status).toBe(200);
    expect(data.email).toBe("jane@example.com");
  });

  it("translates a 400 problem-details response into registration_failed", async () => {
    vi.mocked(verifyTurnstileToken).mockResolvedValue(true);
    global.fetch = vi.fn().mockResolvedValue({
      status: 400,
      json: async () => ({
        detail:
          "We couldn't complete registration with these details. If you already have an account, try signing in or resetting your password.",
      }),
    }) as unknown as typeof fetch;

    const response = await POST(makeRequest(validBody));
    const data = await response.json();

    expect(response.status).toBe(400);
    expect(data.error).toBe("registration_failed");
    expect(data.message).toContain("We couldn't complete registration");
  });

  it("translates a 429 response into rate_limited", async () => {
    vi.mocked(verifyTurnstileToken).mockResolvedValue(true);
    global.fetch = vi.fn().mockResolvedValue({
      status: 429,
      json: async () => ({ message: "Too many requests. Please try again later." }),
    }) as unknown as typeof fetch;

    const response = await POST(makeRequest(validBody));
    const data = await response.json();

    expect(response.status).toBe(429);
    expect(data.error).toBe("rate_limited");
    expect(data.message).toBe("Too many requests. Please try again later.");
  });
});
