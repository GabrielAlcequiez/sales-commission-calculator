import { Spinner } from '../ui/Spinner';

interface CalculateButtonProps {
  onClick: () => void;
  disabled: boolean;
  loading: boolean;
}

export function CalculateButton({ onClick, disabled, loading }: CalculateButtonProps) {
  return (
    <button
      id="calculate-btn"
      className="btn-calculate"
      onClick={onClick}
      disabled={disabled}
      aria-busy={loading}
      aria-label="Calcular comisiones"
      type="button"
    >
      {loading ? (
        <>
          <Spinner />
          Calculando…
        </>
      ) : (
        'Calcular Comisiones'
      )}
    </button>
  );
}
