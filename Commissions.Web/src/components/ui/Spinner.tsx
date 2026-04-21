export function Spinner({ dark = false }: { dark?: boolean }) {
  return (
    <div
      className={`spinner${dark ? ' spinner--dark' : ''}`}
      role="status"
      aria-label="Cargando"
    />
  );
}
