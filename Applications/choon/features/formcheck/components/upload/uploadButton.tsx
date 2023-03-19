import { Button } from "@mantine/core";
import { useRouter } from "next/navigation";
import React from "react";

export default function UploadButton() {
	const router = useRouter();

	return (
		<Button
			sx={{
				backgroundColor: "gray",
			}}
			size="xs"
			onClick={() => router.push("/upload")}
		>
			Upload
		</Button>
	);
}
