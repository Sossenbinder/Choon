import UploadBox from "@formcheck/components/upload/uploadbox";
import { createStyles } from "@mantine/core";

const useStyles = createStyles(() => ({
  container: {
    height: "100%",
    width: "100%",
  },
}));

export function FormCheckUploadPage() {
  const { classes } = useStyles();

  return (
    <div className={classes.container}>
      <UploadBox />
    </div>
  );
}
