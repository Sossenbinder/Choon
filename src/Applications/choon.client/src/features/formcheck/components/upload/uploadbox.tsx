import React from "react";
import { Center, createStyles, Divider } from "@mantine/core";
import UploadFilePicker from "./uploadFilepicker";
import { Form, UploadForm } from "./uploadForm";
import useServices from "@hooks/useServices";
import { useIsMobile } from "@hooks/mediaQueries/useIsMobile";

const useStyles = createStyles((theme) => ({
  container: {
    height: "100%",
    width: "100%",
    display: "grid",
    gridTemplateColumns: "2fr 2em 1fr",
    [theme.fn.smallerThan("md")]: {
      gridTemplateColumns: "1fr",
      gridTemplateRows: "1fr 2em 1fr",
    },
  },
}));

export default function UploadBox() {
  const { classes } = useStyles();
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
          orientation={isMobile ? "horizontal" : "vertical"}
          sx={() => {
            return isMobile
              ? {
                  height: "1px",
                  width: "100%",
                  margin: "16px",
                }
              : {};
          }}
        />
      </Center>
      <UploadForm onSubmit={upload} />
    </div>
  );
}
