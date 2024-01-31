import '@mantine/core/styles.css';
import ServiceContextProvider, { Services } from '@common/contexts/serviceContext';
import FormCheckContentService from '@formcheck/services/formCheckContentService';
import { AppShell, Center, MantineProvider } from '@mantine/core';
import { useMemo } from 'react';
import classes from './layout.module.scss';
import NavBar from '@common/navBar';
import { Configuration } from '../common/components/contexts/configContext';
import configJson from '@root/configuration.json';

export default function RootLayout({ children }: { children: React.ReactNode }) {
    const config = useMemo<Configuration>(buildConfiguration, []);
    const services = useMemo<Services>(() => buildServices(config), [config]);

    return (
        <ServiceContextProvider context={services}>
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

const buildServices = (configuration: Configuration): Services => ({
    formCheckContentService: new FormCheckContentService(configuration),
});

const buildConfiguration = (): Configuration => {
    return configJson as Configuration;
};
