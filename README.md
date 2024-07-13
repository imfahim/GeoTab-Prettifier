# GeoTab-Prettifier
 Assumptions:

    • The input numbers can be positive or negative.
    • The prettifier should handle numbers in millions, billions, and trillions.
    • If the prettified number is an integer, it should not show decimal places.
    • The solution should be easily extensible for other units (e.g., thousands, quadrillions) if needed in the future.

Design Decisions:

    • Strategy Pattern: Used to handle different prettification strategies (millions, billions, trillions). This makes the code modular and easy to extend with new strategies.
    • FastEndpoints: Chosen for building the API due to its high performance and simplicity.
    • Dependency Injection: Used to inject strategies and the prettifier class into the endpoint, adhering to the Dependency Inversion Principle.
    • Kestrel Configuration: Configured to listen on a specific port for simplicity and clarity during testing and deployment.
    • Testing: Both unit and integration tests are implemented to ensure the correctness of the functionality.
