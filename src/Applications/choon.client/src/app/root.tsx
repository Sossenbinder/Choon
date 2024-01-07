import { Router, RouterProvider } from '@tanstack/react-router';
import { routeTree } from './routing/rootRoutes';

export function Root() {
    const router = new Router({ routeTree });
    return <RouterProvider router={router} />;
}
