import apiClient from './client';
import type { Country } from '../types';

export const getCountries = async (): Promise<Country[]> => {
  const { data } = await apiClient.get<Country[]>('/countries');
  // filtro de los paises activos, por si la aplicación escala
  return data.filter((c) => c.isActive);
};
