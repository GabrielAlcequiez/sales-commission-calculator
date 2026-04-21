import apiClient from './client';
import type { CreateSaleRequest, Sales } from '../types';

export const createSale = async (payload: CreateSaleRequest): Promise<Sales> => {
  const { data } = await apiClient.post<Sales>('/sales', payload);
  return data;
};
