import '@mantine/core/styles.css';
import ServiceContextProvider, { ServiceContext } from '@common/contexts/serviceContext';
import FormCheckContentService from '@formcheck/services/formCheckContentService';
import { AppShell, Center, MantineProvider } from '@mantine/core';
import { useRef } from 'react';
import classes from './layout.module.scss';
import NavBar from '@common/navBar';

export default function RootLayout({ children }: { children: React.ReactNode }) {
    const services = useRef<ServiceContext>({
        formCheckContentService: new FormCheckContentService(),
    });

    return (
        <ServiceContextProvider context={services.current}>
            <MantineProvider
                theme={{
                    colors: {
                        dark: ['#d5d7e0', '#acaebf', '#8c8fa3', '#666980', '#4d4f66', '#34354a', '#2b2c3d', '#1d1e30', '#0c0d21', '#01010a'],
                    },
                }}
            >
                <AppShell padding="md" header={{ height: 40 }}>
                    <AppShell.Header>
                        <NavBar />
                    </AppShell.Header>

                    <AppShell.Navbar p="md">Navbar</AppShell.Navbar>
                    <AppShell.Main className={classes.mainSection}>
                        <RootCenter>{children}</RootCenter>
                    </AppShell.Main>
                </AppShell>
            </MantineProvider>
        </ServiceContextProvider>
    );
}

const RootCenter = ({ children }: { children: React.ReactNode }) => {
    return (
        <Center className={classes.contentContainer}>
            <div className={classes.content}>{children}</div>
        </Center>
    );
};
