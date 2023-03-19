"use client";
import React from "react";
import { ActionIcon, Box, Center, createStyles, Divider, Flex, Text } from "@mantine/core";
import { IconCloudUpload } from "@tabler/icons-react";

const useStyles = createStyles((_) => ({
	container: {
		height: "100%",
		width: "100%",
		display: "grid",
		gridTemplateAreas: `
			upload separator controls
		`,
		gridTemplateColumns: "2fr 2em 1fr",
	},
	uploadSection: {
		height: "100%",
		width: "100%",
	},
}));

export default function Page() {
	const { classes } = useStyles();

	const upload = () => {};

	return (
		<div className={classes.container}>
			<Box
				m="md"
				sx={(theme) => ({
					background: theme.colorScheme === "dark" ? theme.colors.dark[3] : theme.colors.gray[2],
					border: "1px dashed black",
					borderRadius: "15px",
				})}
			>
				<Center className={classes.uploadSection} onClick={upload}>
					<Flex direction="column" align="center">
						<IconCloudUpload></IconCloudUpload>
						<Text>Upload your clip here</Text>
					</Flex>
				</Center>
			</Box>
			<Center>
				<Divider my="md" size="md" orientation="vertical" />
			</Center>
			<Box sx={(_) => ({ background: "grey" })}>Right</Box>
		</div>
	);
}
