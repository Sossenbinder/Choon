"use client";
import { AppShell, Header, MantineProvider, Navbar } from "@mantine/core";
import * as React from "react";
import NavBar from "../components/common/navBar";

export default function RootLayout({ children }: { children: React.ReactNode }) {
	return (
		<html style={{ height: "100vh", width: "100vw" }}>
			<body style={{ height: "100vh", width: "100vw", margin: 0 }}>
				<MantineProvider
					withGlobalStyles
					withNormalizeCSS
					theme={{
						colorScheme: "dark",
						colors: {
							dark: ["#d5d7e0", "#acaebf", "#8c8fa3", "#666980", "#4d4f66", "#34354a", "#2b2c3d", "#1d1e30", "#0c0d21", "#01010a"],
						},
					}}
				>
					<AppShell
						padding="md"
						header={<NavBar />}
						styles={(theme) => ({
							main: { backgroundColor: theme.colorScheme === "dark" ? theme.colors.dark[8] : theme.colors.gray[0] },
						})}
					>
						{children}
					</AppShell>
				</MantineProvider>
			</body>
		</html>
	);
}
