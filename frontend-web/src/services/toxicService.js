export const GetToxicPostStats = async (timePeriod) => {
    try {
        // Mock response data for demonstration
        const mockData = {
            week: {
                labels: ['Week 1', 'Week 2', 'Week 3', 'Week 4'],
                data: [5, 8, 3, 10], // Number of toxic posts for each week
            },
            month: {
                labels: ['Jan', 'Feb', 'Mar', 'Apr'],
                data: [15, 20, 18, 22], // Number of toxic posts for each month
            },
        };

        return new Promise((resolve) => {
            setTimeout(() => {
                resolve(mockData[timePeriod]); // Return the corresponding mock data based on the timePeriod (week/month)
            }, 1000);
        });
    } catch (error) {
        throw new Error('Failed to fetch data');
    }
};
