export interface productInfo {
  id: string | null;
  photo: any;
  name: string | null;
  provider: string | null;
  isActive: boolean | null;
  createdOn: string | null;
}

export interface productInfoResponse {
  content: productInfo;
  msg: string;
}