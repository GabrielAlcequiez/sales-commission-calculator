interface ErrorMessageProps {
  message: string;
}

export function ErrorMessage({ message }: ErrorMessageProps) {
  return (
    <div className="error-message" role="alert">
      <span className="error-message__icon">⚠️</span>
      <p className="error-message__text">{message}</p>
    </div>
  );
}
