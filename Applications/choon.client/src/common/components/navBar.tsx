import UploadButton from "@formcheck/components/upload/uploadButton";
import { createStyles, Flex, Header, Group } from "@mantine/core";
import { Link } from "react-router-dom";
import ThemeToggleButton from "./controls/themeToggleButton";

const useStyles = createStyles(() => ({
  header: {
    height: "100%",
    margin: "0 1em",
  },
}));

export default function NavBar() {
  const { classes } = useStyles();

  return (
    <Header height={40}>
      <Flex justify="space-between" align="center" className={classes.header}>
        <Link to="/">Choon</Link>
        <Group>
          <ThemeToggleButton />
          <UploadButton />
        </Group>
      </Flex>
    </Header>
  );
}
