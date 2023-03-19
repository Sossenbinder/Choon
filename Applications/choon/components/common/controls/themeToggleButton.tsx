import { ActionIcon, useMantineColorScheme } from "@mantine/core";
import { IconMoon, IconSun, TablerIconsProps } from "@tabler/icons-react";
import React from "react";

export default function ThemeToggleButton() {
	const { colorScheme, toggleColorScheme } = useMantineColorScheme();

	const props: TablerIconsProps = {
		color: colorScheme === "light" ? "black" : "white",
		size: "1.125rem",
	};

	return (
		<ActionIcon variant="default" onClick={() => toggleColorScheme()}>
			{colorScheme === "dark" ? <IconSun {...props} /> : <IconMoon {...props} />}
		</ActionIcon>
	);
}
