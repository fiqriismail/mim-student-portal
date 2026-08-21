import { NextRequest, NextResponse } from "next/server";
import { verifyTurnstileToken } from "@/lib/turnstile";

const DEFAULT_API_BASE_URL = "http://localhost:5176";

interface RegisterRequestBody {
  fullName: string;
  email: string;
  phone: string;
  password: string;
  passwordConfirmation: string;
  turnstileToken: string;
}

export async function POST(request: NextRequest) {
  const body = (await request.json()) as RegisterRequestBody;
  const { turnstileToken, ...registerFields } = body;

  const remoteIp = request.headers.get("x-forwarded-for") ?? undefined;
  const captchaValid = await verifyTurnstileToken(turnstileToken, remoteIp);

  if (!captchaValid) {
    return NextResponse.json({ error: "captcha_failed" }, { status: 400 });
  }

  const apiBaseUrl = process.env.API_BASE_URL ?? DEFAULT_API_BASE_URL;

  const apiResponse = await fetch(`${apiBaseUrl}/identity/register`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(registerFields),
  });

  if (apiResponse.status === 200) {
    const data = (await apiResponse.json()) as { email: string };
    return NextResponse.json({ email: data.email }, { status: 200 });
  }

  if (apiResponse.status === 429) {
    const data = await apiResponse.json().catch(() => ({}) as { message?: string });
    return NextResponse.json(
      {
        error: "rate_limited",
        message: data.message ?? "Too many requests. Please try again later.",
      },
      { status: 429 },
    );
  }

  const data = await apiResponse.json().catch(() => ({}) as { detail?: string });
  return NextResponse.json(
    {
      error: "registration_failed",
      message:
        data.detail ??
        "We couldn't complete registration with these details. If you already have an account, try signing in or resetting your password.",
    },
    { status: 400 },
  );
}
