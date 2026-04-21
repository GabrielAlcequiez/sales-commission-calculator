export interface Country {
  id: string;
  name: string;
  commission: number;
  isActive: boolean;
}

export interface Sales {
  id: string;
  total_Sales: number;
  discount: number;
  total_Commission: number;
  id_Country: string;
  country?: Country;
  createdAt: string;
}

// DTO enviado al POST /api/sales
export interface CreateSaleRequest {
  total_Sales: number;
  discount: number;
  id_Country: string;
}

export const displayCountryName = (name: string): string =>
  name.replace(/_/g, ' ');

export const displayCommission = (rate: number): string =>
  `${rate}%`;

export const formatCurrency = (value: number): string =>
  new Intl.NumberFormat('es-CO', {
    style: 'currency',
    currency: 'USD',
    minimumFractionDigits: 2,
  }).format(value);
