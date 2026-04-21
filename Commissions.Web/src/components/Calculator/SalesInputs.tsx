interface SalesInputsProps {
  totalSales: string;
  discounts: string;
  onTotalSalesChange: (value: string) => void;
  onDiscountsChange: (value: string) => void;
}

export function SalesInputs({
  totalSales,
  discounts,
  onTotalSalesChange,
  onDiscountsChange,
}: SalesInputsProps) {
  return (
    <div className="fields-row">
      <div className="field">
        <label htmlFor="total-sales" className="field__label">
          Ventas Totales
        </label>
        <input
          id="total-sales"
          type="number"
          className="field__input"
          placeholder="0.00"
          min="0.01"
          step="0.01"
          value={totalSales}
          onChange={(e) => onTotalSalesChange(e.target.value)}
          aria-label="Ventas totales en USD"
        />
      </div>

      <div className="field">
        <label htmlFor="discounts" className="field__label">
          Descuentos
        </label>
        <input
          id="discounts"
          type="number"
          className="field__input"
          placeholder="0.00"
          min="0"
          step="0.01"
          value={discounts}
          onChange={(e) => onDiscountsChange(e.target.value)}
          aria-label="Descuentos aplicados en USD"
        />
      </div>
    </div>
  );
}
