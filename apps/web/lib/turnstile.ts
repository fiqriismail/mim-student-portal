const SITEVERIFY_URL = "https://challenges.cloudflare.com/turnstile/v0/siteverify";
const DEFAULT_TEST_SECRET_KEY = "1x0000000000000000000000000000000AA";

export async function verifyTurnstileToken(
  token: string,
  remoteIp?: string,
): Promise<boolean> {
  const secretKey = process.env.TURNSTILE_SECRET_KEY ?? DEFAULT_TEST_SECRET_KEY;

  const body = new URLSearchParams();
  body.set("secret", secretKey);
  body.set("response", token);
  if (remoteIp) {
    body.set("remoteip", remoteIp);
  }

  const response = await fetch(SITEVERIFY_URL, {
    method: "POST",
    body,
  });

  const data = (await response.json()) as { success: boolean };
  return data.success === true;
}
