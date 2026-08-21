import { RegisterForm } from "@/components/register-form";

export default function RegisterPage() {
  return (
    <main className="flex flex-1 flex-col items-center justify-center gap-6 p-8">
      <h1 className="text-2xl font-bold text-primary">Create your account</h1>
      <RegisterForm />
    </main>
  );
}
