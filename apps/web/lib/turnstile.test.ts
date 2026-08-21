import { describe, expect, it, vi, afterEach } from "vitest";
import { verifyTurnstileToken } from "./turnstile";

describe("verifyTurnstileToken", () => {
  const originalFetch = global.fetch;

  afterEach(() => {
    global.fetch = originalFetch;
    vi.unstubAllEnvs();
  });

  it("returns true when Cloudflare reports success", async () => {
    global.fetch = vi.fn().mockResolvedValue({
      json: async () => ({ success: true }),
    }) as unknown as typeof fetch;

    const result = await verifyTurnstileToken("some-token");

    expect(result).toBe(true);
  });

  it("returns false when Cloudflare reports failure", async () => {
    global.fetch = vi.fn().mockResolvedValue({
      json: async () => ({ success: false }),
    }) as unknown as typeof fetch;

    const result = await verifyTurnstileToken("some-token");

    expect(result).toBe(false);
  });

  it("posts the token and secret to Cloudflare's siteverify endpoint", async () => {
    const fetchMock = vi.fn().mockResolvedValue({
      json: async () => ({ success: true }),
    });
    global.fetch = fetchMock as unknown as typeof fetch;

    await verifyTurnstileToken("some-token", "1.2.3.4");

    expect(fetchMock).toHaveBeenCalledWith(
      "https://challenges.cloudflare.com/turnstile/v0/siteverify",
      expect.objectContaining({ method: "POST" }),
    );
    const body = fetchMock.mock.calls[0][1].body as URLSearchParams;
    expect(body.get("response")).toBe("some-token");
    expect(body.get("remoteip")).toBe("1.2.3.4");
  });
});
