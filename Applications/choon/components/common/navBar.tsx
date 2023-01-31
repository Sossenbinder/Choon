import { Button, createStyles, FileButton, Flex, Header, Text } from "@mantine/core";
import React from "react";

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
				<Button
					sx={{
						backgroundColor: "gray",
					}}
					size="xs"
				>
					Upload
				</Button>
			</Flex>
		</Header>
	);
}
