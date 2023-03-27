import UploadButton from "@formcheck/components/upload/uploadButton";
import { createStyles, Flex, Header, Text, Group } from "@mantine/core";
import React from "react";
import ThemeToggleButton from "./controls/themeToggleButton";

const useStyles = createStyles((_) => ({
	header: {
		height: "100%",
		margin: "0 1em",
	},
}));

export default function NavBar() {
	const { classes } = useStyles();

	return (
		<Header height={40}>
			<Flex justify="space-between" align="center" className={classes.header}>
				<Text>Choon</Text>
				<Group>
					<ThemeToggleButton />
					<UploadButton />
				</Group>
			</Flex>
		</Header>
	);
}
