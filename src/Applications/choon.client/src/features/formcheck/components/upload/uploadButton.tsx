import { Button } from "@mantine/core";
import { useNavigate } from "react-router-dom";

export default function UploadButton() {
  const navigate = useNavigate();

  return (
    <Button
      sx={{
        backgroundColor: "gray",
      }}
      size="xs"
      onClick={() => navigate("/upload")}>
      Upload
    </Button>
  );
}
