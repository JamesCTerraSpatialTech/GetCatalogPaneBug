When looking at the comments for GetCatalogPane(), I noticed a note that this should create a pane if one does not exist.
Unfortunately it doesn't appear to behave this way. The code in this repo adds a button to the add-ins tab to demonstrate.

Expected behavior: The catalog opens even if one isn't open or in view, the Reports item is selected
What happens: If the catalog is open already this works as expected. 
    If the catalog pane is not active but open in a tab group or if the catalog pane is not open then nothing happens.