export interface Product {
  name: string | any;
  categoryId: string | any;
  photo: any | any;
  numberOfLicenses: string | any;
}
export interface ProductResponse {
  content: Product;
  msg: string;
  totalPages: number;
}