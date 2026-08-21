import { redirect } from "next/navigation";

export default async function CheckEmailPage(
  props: PageProps<"/register/check-email">,
) {
  const { email } = await props.searchParams;

  if (!email || Array.isArray(email)) {
    redirect("/register");
  }

  return (
    <main className="flex flex-1 flex-col items-center justify-center gap-4 p-8 text-center">
      <h1 className="text-2xl font-bold text-primary">Check your email</h1>
      <p className="text-muted-foreground">
        We sent a verification link to <strong>{email}</strong>.
      </p>
      <button
        type="button"
        disabled
        title="Resend will be available soon"
        className="text-sm text-muted-foreground underline decoration-dotted disabled:cursor-not-allowed disabled:opacity-50"
      >
        Resend verification email
      </button>
    </main>
  );
}
