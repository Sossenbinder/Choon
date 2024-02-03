import { Button } from '@mantine/core';
import { useNavigate } from '@tanstack/react-router';

export default function LoginAreaButton() {
    const navigate = useNavigate();

    return (
        <Button
            style={{ backgroundColor: 'gray' }}
            size="xs"
            onClick={() =>
                navigate({
                    to: '/login',
                })
            }
        >
            Login
        </Button>
    );
}
