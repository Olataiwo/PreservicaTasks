@restAPi
Feature: Solar Flare (FLR) API


  Scenario: Successful FLR data retrieval with valid parameters
    Given the NASA FLR endpoint with valid startDate, endDate, and API key
    When the request is sent
    Then the response status code should be 200
    And the response should contain flare data

  Scenario: FLR request with missing startDate
    Given the NASA Solar Flare endpoint with the NASA Solar Flare endpoint with a missing start date 
    When the request is sent
    Then the FLR response status code should be 400
    And the response should contain an error message

