import { Box, Image as MantineImage, createStyles, Flex, Text, Center } from "@mantine/core";
import { IconCloudUpload } from "@tabler/icons-react";
import * as React from "react";

const useStyles = createStyles((theme) => ({
	commonSection: {
		height: "100%",
		width: "100%",
		borderRadius: "15px",
	},
	uploadSection: {
		backgroundColor: theme.colorScheme === "dark" ? theme.colors.dark[3] : theme.colors.gray[2],
		backgroundImage:
			"url(\"data:image/svg+xml,%3csvg width='100%25' height='100%25' xmlns='http://www.w3.org/2000/svg'%3e%3crect width='100%25' height='100%25' fill='none' stroke='%23333' stroke-width='10' stroke-dasharray='6%2c 25' stroke-dashoffset='0' stroke-linecap='square'/%3e%3c/svg%3e\")",
		[`&:hover`]: {
			cursor: "pointer",
		},
		["& .uploadHeadsUp"]: {
			height: "100%",
			width: "100%",
			["& .uploadLabel"]: {
				userSelect: "none",
			},
		},
	},
}));

type Props = {
	onFileChanged(file: File): void;
};

export default function UploadFilePicker({ onFileChanged }: Props) {
	const { classes, cx } = useStyles();

	const inputRef = React.useRef<HTMLInputElement>(null);

	const [preview, setPreview] = React.useState<string>();

	const onImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		const uploadedFile = event.currentTarget.files![0];

		onFileChanged(uploadedFile);

		const fileUrl = URL.createObjectURL(uploadedFile);
		setPreview(fileUrl);
	};

	return (
		<Box
			m="md"
			onClick={() => {
				inputRef.current?.click();
			}}
		>
			{!preview ? (
				<Box className={cx(classes.uploadSection, classes.commonSection)}>
					<Flex className="uploadHeadsUp" direction="column" align="center" justify="center">
						<IconCloudUpload />
						<Text className="uploadLabel">Upload your clip here</Text>
					</Flex>
					<input ref={inputRef} type="file" style={{ display: "none" }} onChange={onImageChange} />
				</Box>
			) : (
				<Center className={classes.commonSection}>
					<MantineImage src={preview} />
				</Center>
			)}
		</Box>
	);
}
