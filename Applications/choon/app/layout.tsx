"use client";
import ServiceContextProvider, { ServiceContext } from "@common/contexts/serviceContext";
import NavBar from "@common/navBar";
import FormCheckContentService from "@formcheck/services/formCheckContentService";
import { AppShell, Center, ColorScheme, ColorSchemeProvider, createStyles, MantineProvider } from "@mantine/core";
import * as React from "react";

export default function RootLayout({ children }: { children: React.ReactNode }) {
	const [colorScheme, setColorScheme] = React.useState<ColorScheme>("dark");

	const toggleColorScheme = () => setColorScheme(colorScheme === "dark" ? "light" : "dark");

	const services = React.useRef<ServiceContext>({
		formCheckContentService: new FormCheckContentService(),
	});

	return (
		<html style={{ height: "100vh", width: "100vw" }}>
			<body style={{ height: "100vh", width: "100vw", margin: 0 }}>
				<ServiceContextProvider context={services.current}>
					<ColorSchemeProvider colorScheme={colorScheme} toggleColorScheme={toggleColorScheme}>
						<MantineProvider
							withGlobalStyles
							withNormalizeCSS
							theme={{
								colorScheme,
								colors: {
									dark: ["#d5d7e0", "#acaebf", "#8c8fa3", "#666980", "#4d4f66", "#34354a", "#2b2c3d", "#1d1e30", "#0c0d21", "#01010a"],
								},
							}}
						>
							<AppShell
								padding="md"
								header={<NavBar />}
								styles={(theme) => ({
									main: {
										backgroundColor: theme.colorScheme === "dark" ? theme.colors.dark[8] : theme.colors.gray[0],
									},
									body: {},
								})}
							>
								<RootCenter>{children}</RootCenter>
							</AppShell>
						</MantineProvider>
					</ColorSchemeProvider>
				</ServiceContextProvider>
			</body>
		</html>
	);
}

const centerStyles = createStyles((theme) => ({
	contentContainer: {
		display: "grid",
		placeItems: "center",
		width: "80%",
		maxWidth: "80%",
		minHeight: "100%",
		backgroundColor: theme.colorScheme === "dark" ? theme.colors.dark[5] : theme.colors.gray[1],
	},
}));

const RootCenter = ({ children }: { children: React.ReactNode }) => {
	const { classes } = centerStyles();
	return (
		<Center
			sx={(_) => ({
				height: "100%",
			})}
		>
			<div className={classes.contentContainer}>{children}</div>
		</Center>
	);
};
