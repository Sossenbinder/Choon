import { RouterProvider, createRouter } from '@tanstack/react-router';
import { routeConfig } from './routing/rootRoutes';

const router = createRouter({ routeTree: routeConfig });

declare module '@tanstack/react-router' {
    interface Register {
        router: typeof router;
    }
}

export function Root() {
    return <RouterProvider router={router} />;
}
