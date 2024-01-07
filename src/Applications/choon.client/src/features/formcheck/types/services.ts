import { CreateFormCheckRequest } from "./network";

export interface IFormCheckContentService {
	uploadFormCheckAsset(uploadFile: File, createFormCheckRequest: CreateFormCheckRequest): Promise<void>;
}
