import { createRootRoute, Outlet, createRoute } from '@tanstack/react-router';
import { TanStackRouterDevtools } from '@tanstack/router-devtools';
import RootLayout from 'app/layout';
import FormCheckPage from '../pages/root/formcheckPage';
import { FormCheckUploadPage } from '../pages/upload/formcheckUploadPage';

const rootRoute = createRootRoute({
    component: () => (
        <>
            <RootLayout>
                <Outlet />
            </RootLayout>
            <TanStackRouterDevtools />
        </>
    ),
});

const indexRoute = createRoute({
    getParentRoute: () => rootRoute,
    path: '/',
    component: () => <FormCheckPage />,
});

const uploadRoute = createRoute({
    getParentRoute: () => rootRoute,
    path: '/upload',
    component: () => <FormCheckUploadPage />,
});

export const routeConfig = rootRoute.addChildren([indexRoute, uploadRoute]);
