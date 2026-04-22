import type { Sales } from '../../types';
import { displayCountryName, displayCommission, formatCurrency } from '../../types';

interface ResultDisplayProps {
  result: Sales;
}

export function ResultDisplay({ result }: ResultDisplayProps) {
  const netSales = result.total_Sales - result.discount;
  const countryName = result.country
    ? displayCountryName(result.country.name)
    : 'País desconocido';
  const commissionRate = result.country
    ? displayCommission(result.country.commission)
    : '—';

  return (
    <div className="result-display" role="region" aria-label="Resultado del cálculo">
      <p className="result-display__label">Comisión calculada</p>
      <p className="result-display__commission" aria-live="polite">
        {formatCurrency(result.total_Commission)}
      </p>

      <div className="result-display__details">
        <div className="result-detail">
          <span className="result-detail__key">País</span>
          <span className="result-detail__value">{countryName}</span>
        </div>
        <div className="result-detail">
          <span className="result-detail__key">Tasa aplicada</span>
          <span className="result-detail__value">{commissionRate}</span>
        </div>
        <div className="result-detail">
          <span className="result-detail__key">Ventas totales</span>
          <span className="result-detail__value">{formatCurrency(result.total_Sales)}</span>
        </div>
        <div className="result-detail">
          <span className="result-detail__key">Descuentos</span>
          <span className="result-detail__value">− {formatCurrency(result.discount)}</span>
        </div>
        <div className="result-detail" style={{ borderTop: '1px solid var(--color-accent-mid)', paddingTop: '0.5rem', marginTop: '0.25rem' }}>
          <span className="result-detail__key" style={{ fontWeight: 500, color: 'var(--color-text)' }}>Ventas netas</span>
          <span className="result-detail__value" style={{ fontWeight: 600 }}>{formatCurrency(netSales)}</span>
        </div>
      </div>
    </div>
  );
}
