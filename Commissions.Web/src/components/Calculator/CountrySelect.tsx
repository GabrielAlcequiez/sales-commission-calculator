import type { Country } from '../../types';
import { displayCountryName, displayCommission } from '../../types';
import { Spinner } from '../ui/Spinner';

interface CountrySelectProps {
  countries: Country[];
  loading: boolean;
  value: string;
  onChange: (id: string) => void;
}

export function CountrySelect({ countries, loading, value, onChange }: CountrySelectProps) {
  return (
    <div className="field">
      <label htmlFor="country-select" className="field__label">
        País
      </label>
      <div className="field__select-wrapper">
        {loading ? (
          <div style={{ display: 'flex', alignItems: 'center', gap: '0.5rem', padding: '0.75rem 1rem', border: '1.5px solid var(--color-border)', borderRadius: 'var(--radius-md)' }}>
            <Spinner dark />
            <span style={{ fontSize: '0.875rem', color: 'var(--color-muted)' }}>Cargando países…</span>
          </div>
        ) : (
          <select
            id="country-select"
            className="field__select"
            value={value}
            onChange={(e) => onChange(e.target.value)}
            aria-label="Selecciona el país"
          >
            <option value="" disabled>Selecciona un país</option>
            {countries.map((country) => (
              <option key={country.id} value={country.id}>
                {displayCountryName(country.name)} — {displayCommission(country.commission)}
              </option>
            ))}
          </select>
        )}
      </div>
      {value && (() => {
        const selected = countries.find((c) => c.id === value);
        return selected ? (
          <span className="field__hint">
            Tasa de comisión:{' '}
            <strong className="field__hint--accent">
              {displayCommission(selected.commission)}
            </strong>
          </span>
        ) : null;
      })()}
    </div>
  );
}
