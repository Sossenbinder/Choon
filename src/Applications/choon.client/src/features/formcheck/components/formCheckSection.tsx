import { Flex } from "@mantine/core";
import FormCheckButtons from "./formCheckButtons";
import FormCheckMedia from "./formCheckMedia";

export default function FormCheckSection() {
  return (
    <Flex direction="column" align="center">
      <FormCheckMedia />
      <FormCheckButtons />
    </Flex>
  );
}
