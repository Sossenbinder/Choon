import { useIsMobile } from "@hooks/mediaQueries/useIsMobile";
import { Button, createStyles, Flex, Textarea, TextInput } from "@mantine/core";
import { useForm } from "@mantine/form";

type Props = {
  onSubmit(form: Form): void;
};

export type Form = {
  header: string;
  description: string;
};

const useStyles = createStyles((theme) => ({
  formBox: {
    padding: "2em",
    [theme.fn.smallerThan("md")]: {
      padding: "1em",
    },
  },
}));

export function UploadForm({ onSubmit }: Props) {
  const { classes } = useStyles();

  const isMobile = useIsMobile();

  const inputForm = useForm<Form>({
    initialValues: {
      header: "",
      description: "",
    },
  });

  return (
    <Flex
      justify="space-between"
      direction="column"
      className={classes.formBox}>
      <Flex direction="column" gap="md">
        <TextInput
          withAsterisk
          label="Header"
          placeholder="Heading"
          {...inputForm.getInputProps("header")}
        />
        <Textarea
          label="Description"
          placeholder="Description"
          {...inputForm.getInputProps("description")}
          maxRows={15}
          minRows={isMobile ? undefined : 10}
        />
      </Flex>
      <Button onClick={() => onSubmit(inputForm.values)}>Submit</Button>
    </Flex>
  );
}
