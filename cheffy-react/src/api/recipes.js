import { useMemo } from "react";
import { useCallback } from "react"

const useRecipes = () => {

    // Get all recipes
    const getAll = useCallback(() => {
        // TO-DO: Implement
    }, []);

    // Get recipe by id
    const getById = useCallback(() => {

    }, []);

    const recipesApi = useMemo(() => {
        getAll,
        getById
    }, [getAll, getById]);

    return recipesApi;
}

export default useRecipes;