import { Button } from '@mantine/core';
import { useNavigate } from '@tanstack/react-router';

export default function UploadButton() {
    const navigate = useNavigate();

    return (
        <Button
            style={{ backgroundColor: 'gray' }}
            size="xs"
            onClick={() =>
                navigate({
                    to: '/upload',
                })
            }
        >
            Upload
        </Button>
    );
}
