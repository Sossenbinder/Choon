import React from "react";
import { Box, Center, createStyles, Divider } from "@mantine/core";
import UploadFilePicker from "./uploadFilepicker";

const useStyles = createStyles((theme) => ({
	container: {
		height: "100%",
		width: "100%",
		display: "grid",
		gridTemplateAreas: `
			upload separator controls
		`,
		gridTemplateColumns: "2fr 2em 1fr",
	},
}));

export default function UploadBox() {
	const { classes } = useStyles();

	const upload = () => {};

	return (
		<div className={classes.container}>
			<UploadFilePicker onFileChanged={() => {}} />
			<Center>
				<Divider my="md" size="md" orientation="vertical" />
			</Center>
			<Box sx={(_) => ({ background: "grey" })}>Right</Box>
		</div>
	);
}
