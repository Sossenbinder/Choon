import { useIsMobile } from "@hooks/mediaQueries/useIsMobile";
import { Box, Image as MantineImage, createStyles, Flex, Text, Center, Modal } from "@mantine/core";
import { IconCloudUpload } from "@tabler/icons-react";
import { useRef, useState } from "react";

const useStyles = createStyles((theme) => ({
	commonSection: {
		height: "100%",
		width: "100%",
		borderRadius: "15px",
		maxHeight: "100%",
		maxWidth: "100%",
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

enum FileType {
	Image,
	Video,
}

type PickedFile = {
	fileUrl: string;
	type: FileType;
};

type Props = {
	onFileChanged(file: File): void;
};

export default function UploadFilePicker({ onFileChanged }: Props) {
	const { classes, cx } = useStyles();
	const isMobile = useIsMobile();

	const [preview, setPreview] = useState<PickedFile>();
	const [previewModalOpen, setPreviewModalOpen] = useState(false);

	const inputRef = useRef<HTMLInputElement>(null);
	const headsUpRef = useRef<HTMLDivElement>(null);

	const imageSize = headsUpRef.current?.clientHeight;

	const onImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		const uploadedFile = event.currentTarget.files![0];

		onFileChanged(uploadedFile);

		const fileUrl = URL.createObjectURL(uploadedFile);
		const fileType = uploadedFile.type === "video/mp4" ? FileType.Video : FileType.Image;

		setPreview({
			fileUrl,
			type: fileType,
		});
	};

	return (
		<>
			<Box
				m="md"
				onClick={() => {
					inputRef.current?.click();
				}}
			>
				{!preview ? (
					<Box className={cx(classes.uploadSection, classes.commonSection)}>
						<Flex className="uploadHeadsUp" direction="column" align="center" justify="center" ref={headsUpRef}>
							<IconCloudUpload />
							<Text className="uploadLabel">Upload your clip here</Text>
						</Flex>
						<input ref={inputRef} type="file" style={{ display: "none" }} onChange={onImageChange} />
					</Box>
				) : (
					<Center className={classes.commonSection}>
						{preview.type === FileType.Image ? (
							<MantineImage
								src={preview.fileUrl}
								fit={isMobile ? "contain" : "cover"}
								height={`${imageSize}px`}
								onClick={() => setPreviewModalOpen(true)}
							/>
						) : (
							<video width="100%" src={preview.fileUrl} controls></video>
						)}
					</Center>
				)}

				<Modal opened={previewModalOpen} onClose={() => setPreviewModalOpen(false)} withCloseButton centered title="Upload">
					<MantineImage src={preview?.fileUrl} fit="cover" />
				</Modal>
			</Box>
		</>
	);
}
