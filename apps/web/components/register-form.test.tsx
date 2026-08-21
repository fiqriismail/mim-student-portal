import { describe, expect, it, vi, afterEach } from "vitest";
import { render, screen, waitFor } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { RegisterForm } from "./register-form";

vi.mock("next/navigation", () => ({
  useRouter: () => ({ push: vi.fn() }),
}));

vi.mock("@marsidev/react-turnstile", () => ({
  Turnstile: ({ onSuccess }: { onSuccess: (token: string) => void }) => {
    return (
      <button type="button" data-testid="mock-turnstile-solve" onClick={() => onSuccess("mock-token")}>
        Solve Turnstile
      </button>
    );
  },
}));

async function fillValidFormExceptSubmit(user: ReturnType<typeof userEvent.setup>) {
  await user.type(screen.getByLabelText(/full name/i), "Jane Doe");
  await user.type(screen.getByLabelText(/^email/i), "jane@example.com");
  await user.type(screen.getByLabelText(/phone/i), "0770000000");
  await user.type(screen.getByLabelText(/^password$/i), "verysecurepassword");
  await user.type(screen.getByLabelText(/confirm password/i), "verysecurepassword");
  await user.click(screen.getByLabelText(/terms of use/i));
}

describe("RegisterForm", () => {
  const originalFetch = global.fetch;

  afterEach(() => {
    global.fetch = originalFetch;
    vi.clearAllMocks();
  });

  it("submit button is disabled until the Turnstile challenge succeeds", async () => {
    const user = userEvent.setup();
    render(<RegisterForm />);

    await fillValidFormExceptSubmit(user);

    expect(screen.getByRole("button", { name: /create account/i })).toBeDisabled();

    await user.click(screen.getByTestId("mock-turnstile-solve"));

    await waitFor(() => {
      expect(screen.getByRole("button", { name: /create account/i })).toBeEnabled();
    });
  });

  it("shows a field error on password/confirmation mismatch without clearing either field", async () => {
    const user = userEvent.setup();
    render(<RegisterForm />);

    await user.type(screen.getByLabelText(/^password$/i), "verysecurepassword");
    await user.type(screen.getByLabelText(/confirm password/i), "differentpassword");
    await user.click(screen.getByTestId("mock-turnstile-solve"));
    await user.click(screen.getByRole("button", { name: /create account/i }));

    await waitFor(() => {
      expect(screen.getByText(/password.*match/i)).toBeInTheDocument();
    });

    expect(screen.getByLabelText(/^password$/i)).toHaveValue("verysecurepassword");
    expect(screen.getByLabelText(/confirm password/i)).toHaveValue("differentpassword");
  });

  it("rejects a password shorter than 10 characters", async () => {
    const user = userEvent.setup();
    render(<RegisterForm />);

    await user.type(screen.getByLabelText(/^password$/i), "short1");
    await user.type(screen.getByLabelText(/confirm password/i), "short1");
    await user.click(screen.getByTestId("mock-turnstile-solve"));
    await user.click(screen.getByRole("button", { name: /create account/i }));

    await waitFor(() => {
      expect(screen.getByText(/at least 10 characters/i)).toBeInTheDocument();
    });
  });

  it("blocks submission until the T&C checkbox is ticked", async () => {
    const user = userEvent.setup();
    const fetchMock = vi.fn();
    global.fetch = fetchMock as unknown as typeof fetch;
    render(<RegisterForm />);

    await user.type(screen.getByLabelText(/full name/i), "Jane Doe");
    await user.type(screen.getByLabelText(/^email/i), "jane@example.com");
    await user.type(screen.getByLabelText(/phone/i), "0770000000");
    await user.type(screen.getByLabelText(/^password$/i), "verysecurepassword");
    await user.type(screen.getByLabelText(/confirm password/i), "verysecurepassword");
    await user.click(screen.getByTestId("mock-turnstile-solve"));
    await user.click(screen.getByRole("button", { name: /create account/i }));

    expect(fetchMock).not.toHaveBeenCalled();
  });

  it("shows a form-level banner with the passthrough message on registration failure", async () => {
    const user = userEvent.setup();
    global.fetch = vi.fn().mockResolvedValue({
      ok: false,
      status: 400,
      json: async () => ({
        error: "registration_failed",
        message:
          "We couldn't complete registration with these details. If you already have an account, try signing in or resetting your password.",
      }),
    }) as unknown as typeof fetch;
    render(<RegisterForm />);

    await fillValidFormExceptSubmit(user);
    await user.click(screen.getByTestId("mock-turnstile-solve"));
    await user.click(screen.getByRole("button", { name: /create account/i }));

    await waitFor(() => {
      expect(screen.getByText(/we couldn't complete registration/i)).toBeInTheDocument();
    });
  });
});
