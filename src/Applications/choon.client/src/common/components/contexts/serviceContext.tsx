import { IFormCheckContentService } from "@formcheck/types/services";
import * as React from "react";

export type ServiceContext = {
	formCheckContentService: IFormCheckContentService;
};

export const Context = React.createContext<ServiceContext>({} as ServiceContext);

export type Props = {
	context: ServiceContext;
	children: React.ReactNode;
};

export default function ServiceContextProvider({ context, children }: Props) {
	return <Context.Provider value={context}>{children}</Context.Provider>;
}