import { useIsMobile } from '@hooks/mediaQueries/useIsMobile';
import { Box, Image as MantineImage, Flex, Text, Center, Modal, useMantineTheme, useMantineColorScheme } from '@mantine/core';
import { IconCloudUpload } from '@tabler/icons-react';
import { useRef, useState } from 'react';
import classes from './uploadFilepicker.module.scss';
import cx from 'clsx';

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
    const isMobile = useIsMobile();
    const theme = useMantineTheme();
    const mantineColorScheme = useMantineColorScheme();

    const [preview, setPreview] = useState<PickedFile>();
    const [previewModalOpen, setPreviewModalOpen] = useState(false);

    const inputRef = useRef<HTMLInputElement>(null);
    const headsUpRef = useRef<HTMLDivElement>(null);

    const imageSize = headsUpRef.current?.clientHeight;

    const onImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const uploadedFile = event.currentTarget.files![0];

        onFileChanged(uploadedFile);

        const fileUrl = URL.createObjectURL(uploadedFile);
        const fileType = uploadedFile.type === 'video/mp4' ? FileType.Video : FileType.Image;

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
                        <Flex className={classes.uploadHeadsup} direction="column" align="center" justify="center" ref={headsUpRef}>
                            <IconCloudUpload />
                            <Text className={classes.uploadLabel}>Upload your clip here</Text>
                        </Flex>
                        <input ref={inputRef} type="file" style={{ display: 'none' }} onChange={onImageChange} />
                    </Box>
                ) : (
                    <Center className={cx(classes.uploadSection, classes.commonSection)}>
                        {preview.type === FileType.Image ? (
                            <MantineImage src={preview.fileUrl} fit={isMobile ? 'contain' : 'cover'} height={`${imageSize}px`} onClick={() => setPreviewModalOpen(true)} />
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
