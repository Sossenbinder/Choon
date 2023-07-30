import RootLayout from "./layout";
import { PageRouter } from "./routing/pageRouter";

export function Root() {
  return (
    <RootLayout>
      <PageRouter />
    </RootLayout>
  );
}
