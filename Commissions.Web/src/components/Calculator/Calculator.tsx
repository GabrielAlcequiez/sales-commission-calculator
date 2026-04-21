import { useState } from 'react';
import { useCountries } from '../../hooks/useCountries';
import { useCalculation } from '../../hooks/useCalculation';
import { CountrySelect } from './CountrySelect';
import { SalesInputs } from './SalesInputs';
import { CalculateButton } from './CalculateButton';
import { ResultDisplay } from './ResultDisplay';
import { ErrorMessage } from '../ui/ErrorMessage';

export function Calculator() {
  const { countries, loading: loadingCountries, error: countriesError } = useCountries();
  const { result, loading: calculating, error: calcError, calculate, reset } = useCalculation();

  const [selectedCountryId, setSelectedCountryId] = useState('');
  const [totalSales, setTotalSales] = useState('');
  const [discounts, setDiscounts] = useState('');

  const parsedTotal = parseFloat(totalSales);
  const parsedDiscount = parseFloat(discounts || '0');

  const isValid =
    selectedCountryId !== '' &&
    !isNaN(parsedTotal) &&
    parsedTotal > 0 &&
    !isNaN(parsedDiscount) &&
    parsedDiscount >= 0 &&
    parsedDiscount < parsedTotal;

  const handleCalculate = () => {
    if (!isValid) return;
    calculate({
      total_Sales: parsedTotal,
      discount: parsedDiscount,
      id_Country: selectedCountryId,
    });
  };

  const handleCountryChange = (id: string) => {
    setSelectedCountryId(id);
    reset();
  };

  const handleTotalSalesChange = (value: string) => {
    setTotalSales(value);
    reset();
  };

  const handleDiscountsChange = (value: string) => {
    setDiscounts(value);
    reset();
  };

  return (
    <div className="calculator-card">
      <div className="calculator-header">
        <h1 className="calculator-title">Calculadora de<br />Comisiones</h1>
        <p className="calculator-subtitle">
          Ingresa los datos de venta para obtener la comisión calculada
        </p>
      </div>

      {countriesError && <ErrorMessage message={countriesError} />}

      <div className="calculator-form">
        <CountrySelect
          countries={countries}
          loading={loadingCountries}
          value={selectedCountryId}
          onChange={handleCountryChange}
        />

        <SalesInputs
          totalSales={totalSales}
          discounts={discounts}
          onTotalSalesChange={handleTotalSalesChange}
          onDiscountsChange={handleDiscountsChange}
        />

        {calcError && <ErrorMessage message={calcError} />}

        <CalculateButton
          onClick={handleCalculate}
          disabled={!isValid || calculating || result !== null}
          loading={calculating}
        />
      </div>

      {result && <ResultDisplay result={result} />}
    </div>
  );
}
