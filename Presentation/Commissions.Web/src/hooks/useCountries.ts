import { useState, useEffect } from 'react';
import { getCountries } from '../api/countries';
import type { Country } from '../types';

export function useCountries() {
  const [countries, setCountries] = useState<Country[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    getCountries()
      .then(setCountries)
      .catch(() => setError('No se pudieron cargar los países. Verifica que la API esté corriendo.'))
      .finally(() => setLoading(false));
  }, []);

  return { countries, loading, error };
}
