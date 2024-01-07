import { Outlet, RootRoute, Route } from '@tanstack/react-router';
import { TanStackRouterDevtools } from '@tanstack/router-devtools';
import RootLayout from 'app/layout';
import FormCheckPage from '../pages/root/formcheckPage';
import { FormCheckUploadPage } from '../pages/upload/formcheckUploadPage';

const rootRoute = new RootRoute({
    component: () => (
        <>
            <RootLayout>
                <Outlet />
            </RootLayout>
            <TanStackRouterDevtools />
        </>
    ),
});

const indexRoute = new Route({
    getParentRoute: () => rootRoute,
    path: '/',
    component: () => <FormCheckPage />,
});

const uploadRoute = new Route({
    getParentRoute: () => rootRoute,
    path: '/upload',
    component: () => <FormCheckUploadPage />,
});

export const routeTree = rootRoute.addChildren([indexRoute, uploadRoute]);
