import React from 'react';
import { Center, Divider } from '@mantine/core';
import UploadFilePicker from './uploadFilepicker';
import { Form, UploadForm } from './uploadForm';
import useServices from '@hooks/useServices';
import { useIsMobile } from '@hooks/mediaQueries/useIsMobile';
import classes from './uploadbox.module.scss';

export default function UploadBox() {
    const isMobile = useIsMobile();

    const [uploadFile, setUploadFile] = React.useState<File>();

    const { formCheckContentService } = useServices();

    const upload = async (form: Form) => {
        if (!uploadFile) {
            return;
        }

        await formCheckContentService.uploadFormCheckAsset(uploadFile, form);
    };

    return (
        <div className={classes.container}>
            <UploadFilePicker onFileChanged={setUploadFile} />
            <Center>
                <Divider
                    my="md"
                    size="md"
                    orientation={isMobile ? 'horizontal' : 'vertical'}
                    style={
                        isMobile
                            ? {
                                  height: '1px',
                                  width: '100%',
                                  margin: '16px',
                              }
                            : {}
                    }
                />
            </Center>
            <UploadForm onSubmit={upload} />
        </div>
    );
}
