import { IFormCheckContentService } from '@formcheck/types/services';
import * as React from 'react';

export type Services = {
    formCheckContentService: IFormCheckContentService;
};

export const Context = React.createContext<Services>({} as Services);

export default function ServiceContextProvider({
    context,
    children,
}: React.PropsWithChildren<{
    context: Services;
}>) {
    return <Context.Provider value={context}>{children}</Context.Provider>;
}
