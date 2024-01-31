import { useContext } from 'react';
import { Context, Services } from '../components/contexts/serviceContext';

export default function useServices(): Services {
    return useContext(Context);
}
