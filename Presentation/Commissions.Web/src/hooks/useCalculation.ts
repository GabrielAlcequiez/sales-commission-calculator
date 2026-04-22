import { useState } from 'react';
import { createSale } from '../api/sales';
import type { CreateSaleRequest, Sales } from '../types';

export function useCalculation() {
  const [result, setResult] = useState<Sales | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const calculate = async (payload: CreateSaleRequest) => {
    setLoading(true);
    setError(null);
    setResult(null);
    try {
      const data = await createSale(payload);
      setResult(data);
    } catch {
      setError('Error al calcular la comisión. Verifica los datos e intenta de nuevo.');
    } finally {
      setLoading(false);
    }
  };

  const reset = () => {
    setResult(null);
    setError(null);
  };

  return { result, loading, error, calculate, reset };
}
