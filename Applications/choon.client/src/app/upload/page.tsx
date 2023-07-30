"use client";
import React from "react";
import { createStyles } from "@mantine/core";
import UploadBox from "@formcheck/components/upload/uploadbox";

const useStyles = createStyles((theme) => ({
	container: {
		height: "100%",
		width: "100%",
	},
}));

export default function Page() {
	const { classes } = useStyles();

	return (
		<div className={classes.container}>
			<UploadBox />
		</div>
	);
}
