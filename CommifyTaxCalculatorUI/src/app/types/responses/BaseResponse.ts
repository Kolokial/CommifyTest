export interface BaseResponse {
  isSuccess: boolean;
  error: ErrorResponse;
}

export interface ErrorResponse {
  errorMessage: string;
}
